//import React, { Component } from 'react';

//export class AddStock extends Component {
//    static displayName = AddStock.name;

//    constructor(props) {
//        super(props);
//        this.state = { stockName: '', stockPrice: '' };
//    }

//    handleChange = ({ target }) => {
//        this.setState({ [target.name]: target.value });
//    };

//    onSubmit = event => {
//        const name = this.stockName.value;
//        const price = this.stockPrice.value;
//        const info = { name: name, price: price };
//        const data = this.state.data;

//    }


//    addNewStock = () => {
//        const name = this.stockName.value;
//        const price = this.stockPrice.value;

//        const requestOptions = {
//            method: 'POST',
//            headers: { 'Content-Type': 'application/json' },
//            body: JSON.stringify({
//                "name": '"' +(name) +'",'
//                "price": {this.stockPrice.value }
//            })

//        };
//        fetch('stock', requestOptions)
//            .then(response => response.json())
//            .then(data => this.setState({ postId: data.id }));
//    }
    


//    render() {
//        return (
//            <React.Fragment>

//                <form className="form-inline" onSubmit={this.onSubmit}>
//                <label htmlFor="stockName">Stock Name</label>
//                <input
//                    type="text"
//                    name="stockName"
//                    placeholder="FTSE"
//                    value={this.state.stockName}
//                    onChange={this.handleChange}
//                />

//                <label htmlFor="stockPrice">Stock Price</label>
//                <input
//                    type="text"
//                    placeholder="4000"
//                    name="stockPrice"
//                    value={this.state.stockPrice}
//                    onChange={this.handleChange}
//                    />
//                    <button
//                        type="submit"
//                        className="btn btn-primary"
//                        onClick={this.addNewStock}>Add
//                        </button>
//                </form>

//            <h1> Stock name and price is : {this.state.stockName} {this.state.stockPrice} </h1>
//            </React.Fragment>

//        );
//    }
//}
