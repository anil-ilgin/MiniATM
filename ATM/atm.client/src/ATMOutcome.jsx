import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import "./ATMOutcome.css";
import bill500 from "./assets/bill500.png"

const ATMOutcome = () => {
    const location = useLocation();
    const navigate = useNavigate();
    const { amount, data } = location.state || { amount: 0, data: {} };

    const groupedData = data.withdrawedCashAmounts?.reduce((acc, item) => {
        if (!acc[item.cashType]) {
            acc[item.cashType] = [];
        }
        acc[item.cashType].push(item);
        return acc;
    }, {}) || {};

    const columns = [
        { title: "Banknotes", key: "BankNotes", icon: <img src={bill500}/> },
        { title: "Large Coins", key: "LargeCoins", icon: "⚪" },
        { title: "Small Coins", key: "SmallCoins", icon: "⚪" },
    ];

    return (
        <div className="atm-container">
            <button className="back-button" onClick={() => navigate("/")}>
                ←
            </button>
            <h1>Depositing</h1>
            <div className="amount-display">
                <span className="currency-symbol">£</span>
                <span className="amount">{amount}</span>
            </div>
            <div className="columns">
                {columns.map((column) => (
                    <div key={column.key} className="column">
                        {groupedData[column.key]?.map((item, index) => (
                            <div key={index} className="item">
                                <span className="icon">{column.icon}</span>
                                <span className="text">
                                    {item.amount} x {item.cashAmount}
                                </span>
                            </div>
                        ))}
                    </div>
                ))}
            </div>
            <footer>Thank you for using Enalyzer ATM</footer>
        </div>
    );
};

export default ATMOutcome;
