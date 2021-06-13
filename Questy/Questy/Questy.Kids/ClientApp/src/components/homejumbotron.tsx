import * as React from 'react';

export class HomeJumbotron extends React.Component {
    render() {
        return <div className="jumbotron text-center">
            <h1 className="display-4">
                Welcome to Questy.Kids!&nbsp;
                <img src={require('../img/temp-questy-avatar.png')} height="80" />
            </h1>
            <p className="lead">An application meant to redesign the way kids think about chores, learning, and growing up.</p>
            <hr className="my-4"></hr>
            <p>By gamifying everyday responsibilities it turns the mundane into fun!</p>
            <br />
            <div className="row">
                <div className="col-md-4 offset-md-4 d-flex justify-content-center align-self-center">
                    <button className="button">
                        Learn More
                    <div className="button__horizontal"></div>
                        <div className="button__vertical"></div>
                    </button>
                </div>
            </div>
        </div>
    }
}