/* eslint react/no-multi-comp: 0, react/prop-types: 0 */

import React, { useState } from 'react';
import { Button, Modal, ModalBody } from 'reactstrap';
import Login from './Login'

const CustomModal = () => {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);
    return (

        <div>
            <Button color="primary" onClick={toggle}>Log In</Button>
            <Modal isOpen={modal} toggle={toggle} className="">
                <ModalBody>
                    <Login/>
                </ModalBody>
            </Modal>
        </div>
    );
}

export default CustomModal;