import React, { SyntheticEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IEmployee } from "../../models/employee";

interface IRegisterEmpProps{
    currentUser: IEmployee | undefined,
    setCurrentUser: (nextUser: IEmployee) => void
}

function RegisterE(props: IRegisterEmpProps){
    const [email, setEmail] = useState(''); // initial value
    const [password, setPassword] = useState('');
    const [name, setName] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [currentUser, setCurrentUser] = useState('');
    const h = useNavigate();

    const navHome = () => h('/');

    let updateEmail = (e: SyntheticEvent) => {
        // username = ((e.target as HTMLInputElement).value);
        setEmail((e.target as HTMLInputElement).value);
        console.log(`Email is ${email}`);
    }

    let updatePassword = (e: SyntheticEvent) => {
        setPassword((e.target as HTMLInputElement).value);
        console.log(`Password is ${password}`);
    }

    let updateName = (e: SyntheticEvent) => {
        setName((e.target as HTMLInputElement).value);
        console.log(`Name is ${name}`);
    }

    let register = async (e: SyntheticEvent) => {
        console.log(`Username is ${email}, password is ${password} and name is ${name}`);
        if (!email || !password || !name) {
            setErrorMessage('You must have valid email, password and name');

        } else {
            setErrorMessage('');
            try{
                let info = { 
                    id:0,
                    name:name,
                    email:email,
                    password:password
                }
                fetch("https://localhost:7120/employee", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(info)
                }).then(response => response.json())
                .then((data) => {
                    console.log(data);
                    props.setCurrentUser(data);
                    if (data.email === email){
                        // Navigate to the patient dasgboard here
                        // Also set currentUser

                        setCurrentUser(data);
                        h('/dashboardP');

                    } else{
                        setErrorMessage('Could not register user');
                    }
                });
                
            } catch (err){
                setErrorMessage('Could not communicate with API');
            }

        }
    }
    
    return(
        <>
            <br /><br />
            <h3>Register As An Employee</h3>
            <div id="register-form">
                <input id="register-name" type='text' placeholder="Enter Name" onChange={updateName} />
                <br /> <br />
                <input id="register-email" type='text' placeholder="Enter Email" onChange={updateEmail} />
                <br /> <br />
                <input id="register-password" type='password' placeholder="Enter Password" onChange={updatePassword} />
                <br /> <br />
                <button id="register-button" onClick={register}>Register</button>
                <br /> <br />
                <button id="home-button" onClick={navHome}>Home</button>
            </div>
            <div>
                <p>{errorMessage}</p>
            </div>
        </>
    )
}

export default RegisterE;