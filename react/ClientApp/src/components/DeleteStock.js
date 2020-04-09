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

        // DELETE Method
        fetch('stock/' + name, { method: 'DELETE', })
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }));
    }

    render() {
        return (
            <React.Fragment >
                <h1>Delete stocks</h1>

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

                        <button
                            type="submit"
                            className="btn btn-primary"
                            onClick={this.deleteStock}> Remove Stock
                    </button>
                    </div>
                </form>
            </React.Fragment>
        );
    }

}