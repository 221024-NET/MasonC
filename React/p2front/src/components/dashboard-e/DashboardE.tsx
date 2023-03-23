import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { IEmployee } from "../../models/employee";


interface IEmpProps{
    currentUser: IEmployee | undefined,
    setCurrentUser: (nextUser: IEmployee) => void
}

function DashboardE(props: IEmpProps){
    const h = useNavigate();
    const navHome = () => h('/');
    const pending = () => h('/viewPending');
    const allClaims = () => h('/viewAllClaims');
    const changePassE = () => h('/changePassE');
    
    
    useEffect(() => {
        const navTo = () => h('/');
        if(props.currentUser === undefined){
            navTo();
        }
    }, [h, props.currentUser])
    
    return (
        <>
            <h4>Employee Dashboard</h4>
            <div></div>
            <button id="pending" onClick={pending}>Pending Claims</button>
            <button id="allClaims" onClick={allClaims}>All Claims</button>
            <div></div>
            <button id="changePassword" onClick={changePassE}>Change Password</button>
            <div></div>
            <button id="home" onClick={navHome}>Home</button>
        </>
    )
}

export default DashboardE;