import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { IEmployee } from "../../models/employee";

interface IEmpProps{
    currentUser: IEmployee | undefined,
    setCurrentUser: (nextUser: IEmployee) => void
}

function ViewPending(props: IEmpProps) {
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
            <div>View All Pending</div>
            <br /> <br />
            <button id="home-button" onClick={navHome}>Home</button>
        </>
    )
}

export default ViewPending;