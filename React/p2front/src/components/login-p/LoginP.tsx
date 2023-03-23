import React, { SyntheticEvent, useState } from "react";
import { IPatient } from "../../models/patient";
import { useNavigate} from "react-router-dom";


interface ILoginPatProps{
    currentUser: IPatient | undefined,
    setCurrentUser: (nextUser: IPatient) => void
}

function LoginP(props: ILoginPatProps) {
    const [email, setEmail] = useState(''); // initial value
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [currentUser, setCurrentUser] = useState('');
    const h = useNavigate();
    const navTo = () => h('/');

    let updateEmail = (e: SyntheticEvent) => {
        // username = ((e.target as HTMLInputElement).value);
        setEmail((e.target as HTMLInputElement).value);
        console.log(`Email is ${email}`);
    }

    let updatePassword = (e: SyntheticEvent) => {
        setPassword((e.target as HTMLInputElement).value);
        console.log(`Password is ${password}`);
    }

    let login = async (e: SyntheticEvent) => {
        console.log(`Username is ${email} and password is ${password}`);
        if (!email || !password) {
            setErrorMessage('You must have valid email and password');

        } else {
            setErrorMessage('');
            try{
                let info = { 
                    id:0,
                    name:"",
                    email:email,
                    password:password
                }
                fetch("https://localhost:7120/patients/LogIn", {
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
                        setErrorMessage('Could Not Validate Credentials');
                    }
                });
                
            } catch (err){
                setErrorMessage('Could not communicate with API');
            }

        }

    }

    return (
        <>
            <br /><br />
            <h3>Log Into App As A Patient</h3>
            <div id="login-form">
                <input id="login-email" type='text' placeholder="Enter Email" onChange={updateEmail} />
                <br /> <br />
                <input id="login-password" type='password' placeholder="Enter Password" onChange={updatePassword} />
                <br /> <br />
                <button id="login-button" onClick={login}>Login</button>
                <br /> <br />
                <button id="home-button" onClick={navTo}>Home</button>
            </div>
            <div>
                <p>{errorMessage}</p>
            </div>
        </>
    );
}

export default LoginP;