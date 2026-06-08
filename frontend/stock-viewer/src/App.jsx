import { useState } from "react";
import { getStock } from "./APIClient";

import "./App.css";
import { StockInput } from "./Components/StockInput";
import StockViewer from "./Components/StockViewer";

function App() {
  const [stockData, setStockData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchStock = async (symbol) => {
    if (!symbol || symbol.trim() === "") {
      setError("Please enter a stock symbol");
      return;
    }

    setLoading(true);
    setError(null);

    try {
      const res = await getStock(symbol);
      setStockData(res);
    } catch (err) {
      setError(err.message);
      setStockData(null);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="app-container">
      <StockInput onSearch={fetchStock} />

      {loading && <p className="loading">Loading stock data...</p>}

      {error && <p className="error">{error}</p>}

      <StockViewer data={stockData} />
    </div>
  );
}

export default App;