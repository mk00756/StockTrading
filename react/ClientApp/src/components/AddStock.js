import React, { Component } from 'react';

export class AddStock extends Component {
    static displayName = AddStock.name;

    constructor(props) {
        super(props);
    }


    render() {
        return (
            <div>
                <h1>Add stocks</h1>
                <form>
                    <label>
                        Stock Name: 
                        <input type="text" name="name" />
                    </label>   
                    <label>
                        Price: 
                        <input
                            type="number"
                            name="price"
                            value={this.state.stockPrice}
                        />
                </label>   
                </form>

                <button> Add stock </button>
            </div>


        );
    }
}
