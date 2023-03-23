import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IPatient } from "../../models/patient";
import { IClaim } from "../../models/claim";


interface IPatProps{
    currentUser: IPatient | undefined,
    setCurrentUser: (nextUser: IPatient) => void,
}


function DashboardP(props: IPatProps){
    const h = useNavigate();
    const navHome = () => h('/');
    const makeClaim = () => h('/makeClaim');
    const seeMyClaims = () => h('/viewClaimsPatient');
    const changePass = () => h('/changePassP');

    const [claims] = useState<IClaim[]>();
    
    useEffect( () => {
        const navTo = () => h('/');
        if(props.currentUser === undefined){
            navTo();
            
        }
    }, [claims, h, props.currentUser]);

    

    return (
        <>
            <h4>Patient Dashboard</h4>
            <div></div>
            <button id="makeClaim"  onClick={makeClaim}>Make A New Claim</button>
            <button id="seeMyClaims" onClick={seeMyClaims}>Check Status of Claims</button>
            <div></div>
            <button id="changePassword" onClick={changePass}>Change Password</button>
            <div></div>
            <button id="home" onClick={navHome}>Home</button>
        </>
    )
}

export default DashboardP;