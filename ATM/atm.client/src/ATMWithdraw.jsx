import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./ATMWithdraw.css";
import backArrowIcon from "./assets/back-arrow-icon.png"; 
 

const ATMWithdraw = () => {
    const [amount, setAmount] = useState("");
    const navigate = useNavigate();


    const handleButtonClick = (value) => {
        if (value === "back") {
            setAmount(amount.slice(0, -1));
        } else {
            setAmount(amount + value);
        }
    };

    const handleSubmit = async () => {
        if (amount) {
            try {
                const response = await fetch(`/api/CashOperations/withdraw`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({ withdrawRequestAmount: parseInt(amount) }),
                });

                if (!response.ok) {
                    throw new Error(`Error: ${response.statusText}`);
                }

                const data = await response.json();
                navigate("/outcome", { state: { amount, data } });
            } catch (error) {
                alert(`Failed to withdraw: ${error.message}`);
            }
        }
    };


    return (
        <div className="atm-container">
            <h1>Select amount</h1>
            <div className="amount-display">
                <span className="currency-symbol">£</span>
                <span className="amount">{amount}</span>
                <span className="blinking-cursor"></span>
            </div>
            <div className="keypad-container">
                <div className="keypad">
                    {[1, 2, 3, 4, 5, 6, 7, 8, 9, "back", 0].map((key, index) => (
                        <button
                            key={index}
                            className="keypad-button"
                            onClick={() => handleButtonClick(key === "back" ? "back" : key)}
                        >
                            {key === "back" ? (
                                <img
                                    src={backArrowIcon}
                                    alt="Back"
                                    className="back-arrow-icon"
                                />
                            ) : (
                                key
                            )}
                        </button>
                    ))}
                </div>
            </div>
            <div className="submit-container">
                <button
                    className={`submit-button ${amount ? "" : "disabled"}`}
                    onClick={handleSubmit}
                    disabled={!amount}
                >
                    submit
                </button>
            </div>
        </div>
    );
};

export default ATMWithdraw;
