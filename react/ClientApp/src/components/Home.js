import React, { Component } from 'react';

export class Home extends Component {
    static displayName = 'Stocks';

    constructor(props) {
        super(props);
        this.state = { stocks: [], loading: true };
    }

    componentDidMount() {
        this.populateStockData();
    }

    static renderStocksTable(stocks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {stocks.map(stock =>
                        <tr key={stock.name}>
                            <td>{stock.name}</td>
                            <td>{stock.price}</td>
                            <td>{stock.lastUpdated}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderStocksTable(this.state.stocks);

        return (
            <div>
                <h1 id="tabelLabel" >Stock Trading</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    async populateStockData() {
        const response = await fetch('stock');
        const data = await response.json();
        this.setState({ stocks: data, loading: false });
    }
}
