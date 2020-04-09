import React, { Component } from 'react';

export class DeleteStock extends Component {
    static displayName = DeleteStock.name;

    constructor(props) {
        super(props);
        this.state = { stockName: '' };
    }

    handleChange = ({ target }) => {
        this.setState({ [target.name]: target.value });
    };

    // DELETE method is executed on button click
    deleteStock = () => {
        var name = this.state.stockName;
        var price = parseInt(this.state.stockPrice);

        var value = { "name": name, "price": price };


        // DELETE Method
        fetch('stock' + this.state.stockName, { method: 'DELETE', })
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }));
    }

    render() {
        return (
            <React.Fragment >
                <h1>Delete stocks</h1>

                <form className="form-inline" onSubmit={this.onSubmit}>
                    <label htmlFor="stockName">Stock Name </label>
                    <input
                        type="text"
                        name="stockName"
                        placeholder="FTSE"
                        value={this.state.stockName}
                        onChange={this.handleChange}
                    />

                    <button
                        type="submit"
                        className="btn btn-primary"
                        onClick={this.deleteStock}> Remove this stock
                    </button>
                </form>
            </React.Fragment>
        );
    }

}