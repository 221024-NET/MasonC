import React from "react";
import { useNavigate } from "react-router-dom";

function Home() {

    const h = useNavigate();
    const navLogP = () => h('/loginP');
    const navLogE = () => h('/loginE');
    const navRegP = () => h('/registerP');
    const navRegE = () => h('/registerE');

    return (
        <>
            <br /><br />
            <h3>Please select the option.</h3>
            <br /><br />
            <button id="loginp" onClick={navLogP}>Login As Patient</button>
            <button id="logine" onClick={navLogE}>Login As Employee</button>
            <br /><br />
            <button id="registerp" onClick={navRegP}>Register As Patient</button>
            <button id="registere" onClick={navRegE}>Register As Employee</button>
        </>
    );
}

export default Home;