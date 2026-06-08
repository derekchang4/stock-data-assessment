export async function getStock(symbol) {
  const res = await fetch(`http://localhost:5037/api/stocks/${symbol}`)
  
  if (!res.ok) {
    const errorText = await res.text();

    throw new Error(
      `API Error ${res.status}: ${errorText || "Failed to fetch stock"}`
    );
  }

  return await res.json()
}