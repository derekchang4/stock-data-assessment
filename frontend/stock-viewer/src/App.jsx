import { useState } from 'react'
import { getStock } from './APIClient'

import './App.css'
import StockInput from './Components/StockInput'
import StockViewer from './Components/StockViewer'

function App() {
  const [stockData, setStockData] = useState(null)

  const fetchStock = async (symbol) => {
    try {
      const res = await getStock(symbol)
      setStockData(res)
    } catch (err) {
      console.error("Error fetching stock:", err)
    }
  }

  return (
    <div className='app-container'>
      <StockInput onSearch={fetchStock} />
      <StockViewer data={stockData} />
    </div>
  )
}

export default App