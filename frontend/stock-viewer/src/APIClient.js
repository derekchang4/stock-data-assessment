export async function getStock(symbol) {
  const res = await fetch(`http://localhost:5037/api/stocks/${symbol}`)
  
  if (!res.ok) {
    throw new Error("Failed to fetch stock")
  }

  return await res.json()
}