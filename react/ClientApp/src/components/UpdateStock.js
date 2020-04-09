import React, { Component } from 'react';
import '../Styles/ComponentStyle.css';

export class UpdateStock extends Component {
    static displayName = UpdateStock.name;

    constructor(props) {
        super(props);
        this.state = { stockName: '', stockPrice: '' };
    }

    handleChange = ({ target }) => {
        this.setState({ [target.name]: target.value });
    };


    PatchStock = () => {
        var name = this.state.stockName;
        var price = parseFloat(this.state.stockPrice);

        var value = { "name": name, "price": price };
        var url = 'stock/' + name;

        // converts object to a JSON
        const requestOptions = {
            method: 'PATCH',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(value)

        };
        // POST Method
        fetch(url, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }));
    }
       
    render() {
        return (
            <React.Fragment>
                <h1>Update Stock</h1>
                <form>
                    <div className="form-group">
                        <label htmlFor="stockName">Stock Name </label>
                        <input
                            type="text"
                            name="stockName"
                            value={this.state.stockName}
                            onChange={this.handleChange}
                        />
                    </div>
                    <div className="form-group">

                        <label htmlFor="stockPrice">Stock Price </label>
                        <input
                            type="number"
                            placeholder="4000"
                            name="stockPrice"
                            value={this.state.stockPrice}
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="form-group">

                        <button
                            type="submit"
                            className="btn btn-primary"
                            onClick={this.PatchStock}>Update Price
                        </button>
                    </div>
                </form>
            </React.Fragment>
        );
    }
}