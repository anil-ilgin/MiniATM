import React from "react";
import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ATMWithdraw from "./ATMWithdraw";
import ATMOutcome from "./ATMOutcome";
import "./index.css";

createRoot(document.getElementById("root")).render(
    <StrictMode>
        <Router>
            <Routes>
                <Route path="/" element={<ATMWithdraw />} />
                <Route path="/outcome" element={<ATMOutcome />} />
            </Routes>
        </Router>
    </StrictMode>
);

