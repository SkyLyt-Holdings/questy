import * as React from 'react';
import { useHistory } from 'react-router';
import LocalStorage from '../../helpers/LocalStorage';

const Home = () => {
    const history = useHistory();

    React.useEffect(() => {
        const token = LocalStorage.getToken();
        if(token === null && window.location) history.push("/login");
    }, [])
    
return (
<div><h1>??????</h1></div>
    )
}

export default Home;