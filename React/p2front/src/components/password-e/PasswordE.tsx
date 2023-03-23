import React, { SyntheticEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IEmployee } from "../../models/employee";


interface IEmpProps{
    currentUser: IEmployee | undefined,
    setCurrentUser: (nextUser: IEmployee) => void
}

function PasswordE(props: IEmpProps) {
    const h = useNavigate();
    const navHome = () => h('/');
    const [errorMessage, setErrorMessage] = useState('');
    const [pass, setPass] = useState('');

    let updatePassword = (e: SyntheticEvent) => {
        setPass((e.target as HTMLInputElement).value);
        console.log(`Password is ${pass}`);
    }

    let go = () => {
        if(props.currentUser === undefined){
            const navTo = () => h('/');
            navTo();
            
        }else {
            try{
                let info = { 
                    id:props.currentUser.employee_id,
                    name:props.currentUser.name,
                    email: props.currentUser.email,
                    password:pass
                }
                let url = "https://localhost:7120/employee/newPassword/" + props.currentUser.employee_id
                fetch(url, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify([props.currentUser.employee_id, info])
                }).then(res => {
                    return res.json()
                })
                .then(data => console.log(data))
            } catch (err){
                setErrorMessage('Could not communicate with API');
            }
        }
    }

    return(
        <>
            <div>Change Password Employee</div>
            <br /> <br />
            <input id="employee-password" type='password' placeholder="Enter New Password" onChange={updatePassword} />
            <br /> <br />
            <button id="change-pass-button" onClick={go}>Change Password</button>
            <div>
                <p>{errorMessage}</p>
            </div>
        </>
    )
}

export default PasswordE;