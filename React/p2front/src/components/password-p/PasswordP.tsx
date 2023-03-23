import React, { SyntheticEvent, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IPatient } from "../../models/patient";


interface IPatProps{
    currentUser: IPatient | undefined,
    setCurrentUser: (nextUser: IPatient) => void
}


function PasswordP(props: IPatProps) {
    const h = useNavigate();
    const navHome = () => h('/');
    const [pass, setPass] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    useEffect( () => {
        const navTo = () => h('/');
        if(props.currentUser === undefined){
            navTo();
            
        }
    }, [h, props.currentUser]);

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
                const navTo = () => h('/');
                let info = { 
                    id: props.currentUser.patient_id,
                    patient_id: props.currentUser.patient_id,
                    name: props.currentUser.name,
                    email: props.currentUser.email,
                    password:pass
                }
                let url = "https://localhost:7120/patients/newPassword/" + props.currentUser.patient_id
                fetch(url, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(info)
                })
                // }).then(res => {
                //     return res.json()
                // })
                //.then(data => console.log(data));
                navTo();
            } catch (err){
                setErrorMessage('Could not communicate with API');
            }
        }
    }

    return(
        <>
            <div>Change Password Patient</div>
            <br /> <br />
            <input id="patient-password" type='password' placeholder="Enter New Password" onChange={updatePassword} />
            <br /> <br />
            <button id="change-pass-button" onClick={go}>Change Password</button>
            <br /> <br />
            <button id="home-button" onClick={navHome}>Home</button>
            <div>
                <p>{errorMessage}</p>
            </div>
        </>
    )
}

export default PasswordP;
