import React, { SyntheticEvent, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IPatient } from "../../models/patient";


interface IPatProps{
    currentUser: IPatient | undefined,
    setCurrentUser: (nextUser: IPatient) => void
}


function MakeClaim(props: IPatProps) {
    const h = useNavigate();
    const navHome = () => h('/');
    const [errorMessage, setErrorMessage] = useState('');
    const [successMsg, setSuccessMsg] = useState('');
    const [currentUser, setCurrentUser] = useState('');
    const [amount, setAmount] = useState(Number);
    const [details, setDetails] = useState('');

    useEffect( () => {
        const navTo = () => h('/');
        if(props.currentUser === undefined){
            navTo();
        }
    }, [h, props.currentUser]);

    const create = () => {
        try{
            let info = {
                id: 0,
                customer_id: props.currentUser?.patient_id,
                date_submitted: new Date(),
                amount: amount,
                details: details,
                status: "Pending",
                reviewed_by: null
            }

            console.log(JSON.stringify(info));
    
            fetch("https://localhost:7120/claim/new", {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(info)
                    }).then(response => response.json())
                    .then((data) => {
                        console.log(data);
                        if (data.id !== 0 || data.status !== 400) {
                            h('/dashboardP');
    
                        }else{
                            setErrorMessage('Could Not Validate Created Claim');
                        }
                    });

        } catch (err) {
            setErrorMessage('Could not communicate with API');
        }
        
    }

    const updateAmount = (e: SyntheticEvent) => {
        let str = (e.target as HTMLInputElement).value;
        let num = +str;
        setAmount(num);
        console.log(amount);
    }

    const updateDetails = (e: SyntheticEvent) => {
        setDetails((e.target as HTMLInputElement).value);
        console.log(details);
    }

    return(
        <>
            <div>Make A New Claim</div>
            <div id="claim-form">
                <input id="claim-amount" type='text' placeholder="Enter Amount" onChange={updateAmount} />
                <br /> <br />
                <input id="claim-details" type='text' placeholder="Enter Details" onChange={updateDetails} />
                <br /> <br />
                <button id="create-button" onClick={create}>Create Claim</button>
            </div>
            <br /> <br />
            <button id="home-button" onClick={navHome}>Home</button>
            <div>
                <p>{errorMessage}</p>
            </div>
        </>
    )
}

export default MakeClaim;