import './StockViewer.css'

export default function StockViewer({ data }) {
  if (!data) {
    return <p>No data yet</p>;
  }

  return (
    <div className='stock-viewer'>
      <h2>{data.symbol}</h2>

      <table className='stock-table'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Open</th>
            <th>High</th>
            <th>Low</th>
            <th>Close</th>
            <th>Volume</th>
          </tr>
        </thead>

        <tbody>
          {data.data.map((day, index) => (
            <tr key={index}>
              <td>{day.date}</td>
              <td>{day.open}</td>
              <td>{day.high}</td>
              <td>{day.low}</td>
              <td>{day.close}</td>
              <td>{day.volume}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}