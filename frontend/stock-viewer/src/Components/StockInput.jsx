import { useState } from "react";
import './StockInput.css';

export function StockInput({ onSearch }) {
  const [symbol, setSymbol] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    const cleaned = symbol.trim().toUpperCase();

    if (!cleaned) return;

    if (!/^[A-Z.]{1,10}$/.test(cleaned)) {
      alert("Invalid stock symbol");
      return;
    }

    onSearch(cleaned);
  };

  return (
    <form className="stock-input" onSubmit={handleSubmit}>
      <input
        value={symbol}
        onChange={(e) => setSymbol(e.target.value)}
        placeholder="Enter stock symbol (TSLA)"
      />
      <button type="submit">Search</button>
    </form>
  );
}