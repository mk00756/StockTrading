import React, { Component } from 'react';
import '../Styles/ComponentStyle.css';

export class AddStock extends Component {
    static displayName = AddStock.name;

    constructor(props) {
        super(props);
        this.state = { stockName: '', stockPrice: '' };
    }

    handleChange = ({ target }) => {
        this.setState({ [target.name]: target.value });
    };



    // POST method is executed on button click
    addNewStock = () => {
        var name = this.state.stockName;
        var price = parseInt(this.state.stockPrice);

        var value = { "name": name, "price": price };

        // converts object to a JSON
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(value)

        };
        // POST Method
        fetch('stock', requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }));
    }



    render() {

        return (
            <React.Fragment >

                <h1> Add Stock</h1>
                <form>
                    <div className="form-group">

                        <label htmlFor="stockName">Stock Name </label>
                        <input
                            type="text"
                            name="stockName"
                            placeholder="FTSE"
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
                            onClick={this.addNewStock}>Add
                        </button>
                    </div>
                </form>
            </React.Fragment>
        );
    }
}
