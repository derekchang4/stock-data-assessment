import { useState } from "react";
import './StockInput.css';

export default function StockInput({ onSearch }) {
  const [symbol, setSymbol] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!symbol) return;

    onSearch(symbol.toUpperCase());
  };

  return (
    <form 
      onSubmit={handleSubmit} 
      className="stock-input"
    >
      <input
        value={symbol}
        onChange={(e) => setSymbol(e.target.value)}
        placeholder="Enter stock symbol (TSLA)"
      />
      <button type="submit">Search</button>
    </form>
  );
}