import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { IEmployee } from "../../models/employee";

interface IEmpProps{
    currentUser: IEmployee | undefined,
    setCurrentUser: (nextUser: IEmployee) => void
}


function ViewAllClaims(props: IEmpProps) {
    const h = useNavigate();
    const navHome = () => h('/');

    useEffect( () => {
        const navTo = () => h('/');
        if(props.currentUser === undefined){
            navTo();
        }
    }, [h, props.currentUser]);
    
    return(
        <>
            <div>View All Claims</div>
            <br /> <br />
            <button id="home-button" onClick={navHome}>Home</button>
        </>
    )
}

export default ViewAllClaims;