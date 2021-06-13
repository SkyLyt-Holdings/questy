///* eslint react/no-multi-comp: 0, react/prop-types: 0 */

import React from 'react';
import { Button } from 'reactstrap';
import { SiProbot } from 'react-icons/si';
import { RiLockPasswordLine } from 'react-icons/ri';
import { HiOutlineMail } from 'react-icons/hi';
import { FiCheckCircle } from 'react-icons/fi';


class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeLogInClassName: 'active',
            activeSignUpClassName: '',
            activeLogInFormClassName: '',
            activeSignUpFormClassName: 'd-none',
        };
    }
    
    toggleActive = (loginShow, signupShow) => {
        this.state.activeLogInClassName = loginShow ? 'active' : ''
        this.state.activeSignUpClassName = signupShow ? 'active' : ''
        this.state.activeLogInFormClassName = loginShow ? '' : 'd-none'
        this.state.activeSignUpFormClassName = signupShow ? '' : 'd-none'
        this.setState({})
    };



    render() {
        return (
            <div>
                <div className="row text-center">
                    <div className="col">
                        <a href="#" onClick={() => { this.toggleActive(true, false) }} className={`${this.state.activeLogInClassName} mx-2`}>Log In</a>
                        <a href="#" onClick={() => { this.toggleActive(false, true) }} className={`${this.state.activeSignUpClassName} mx-2`}>Sign Up</a>
                    </div>
                </div>
                <div className="d-flex justify-content-center m-5">
                    <img src="https://image.flaticon.com/icons/svg/191/191582.svg" alt="Log in icon" height="200px" />
                </div>
                <div className={`${this.state.activeLogInFormClassName} form-group`}>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonUsername"><SiProbot size={28} /></span>
                        </div>
                        <input id="lblUsername" type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addonUsername" />
                    </div>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonPassword"><RiLockPasswordLine size={28} /></span>
                        </div>
                        <input id="lblPassword" type="password" className="form-control" placeholder="Password" aria-label="Password" aria-describedby="addonPassword" />
                    </div>
                    <div className="row">
                        <div className="col-4 offset-4">
                            <Button color="primary" className="btn-block">Log In</Button>
                        </div>
                    </div>
                </div>
                <div className={`${this.state.activeSignUpFormClassName} form-group`}>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonSignUpUsername"><SiProbot size={28} /></span>
                        </div>
                        <input id="txtSignUpUsername" type="text" className="form-control" placeholder="Username" aria-label="Sign Up Username" aria-describedby="addonSignUpUsername" />
                    </div>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonSignUpEmail"><HiOutlineMail size={28} /></span>
                        </div>
                        <input id="txtSignUpEmail" type="text" className="form-control" placeholder="Email" aria-label="Sign Up Email" aria-describedby="addonSignUpEmail" />
                    </div>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonSignUpPassword"><RiLockPasswordLine size={28} /></span>
                        </div>
                        <input id="txtSignUpPassword" type="password" className="form-control" placeholder="Password" aria-label="Sign Up Password" aria-describedby="addonSignUpPassword" />
                    </div>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="addonSignUpConfirmPassword"><FiCheckCircle size={28} /></span>
                        </div>
                        <input id="txtSignUpConfirmPassword" type="password" className="form-control" placeholder="Confirm Password" aria-label="Sign Up Confirm Password" aria-describedby="addonSignUpConfirmPassword" />
                    </div>
                    <div className="row">
                        <div className="col-4 offset-4">
                            <Button color="primary" className="btn-block">Sign Up</Button>
                        </div>
                    </div>
                </div>
                <hr/>
                <div className="row">
                    <div className="col text-center">
                        <a href="#">Forgot Password</a>
                    </div>
                </div>
            </div>
        );
    }
}

export default Login;

