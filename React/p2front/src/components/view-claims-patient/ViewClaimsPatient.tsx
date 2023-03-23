import React, { SyntheticEvent, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { IClaim } from "../../models/claim";
import { IPatient } from "../../models/patient";
import ClaimCard from "../claim-card/ClaimCard";

interface IPatProps {
    currentUser: IPatient | undefined,
    setCurrentUser: (nextUser: IPatient) => void
    // claims: IClaim | undefined,
    // setClaims: (nextClaim: IClaim) => void
}


function ViewClaimsPatient(props: IPatProps) {
    const h = useNavigate();
    const navHome = () => h('/');
    // const [currentUser, setCurrentUser] = useState('');
    const [state, setState] = useState<IClaim[]>([]);
    //const [claims, setClaims] = useState<IClaim>();
    //     id: 0,
    //     customer_id:0,
    //     date_submitted: new Date(),
    //     amount: 0,
    //     details: '',
    //     status: '',
    //     reviewed_by: 0
    // });
    // const state = {
    //     claims: []
    // }
    //let claims: IClaim[];
    // let count = 0;
    //let listClaims = <></>;
    const [errorMessage, setErrorMessage] = useState('');

    // eslint-disable-next-line react-hooks/exhaustive-deps
    useEffect(() => {
        const navTo = () => h('/');
        if (props.currentUser === undefined) {
            navTo();
        }
    }, [h, props.currentUser]);



    let getClaims = async (e: SyntheticEvent) => {
        try {
            let url = "https://localhost:7120/claims";
            await fetch(url)
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    //setClaims(...claims{id:data.id, customer_id:data.customer_id, date_submitted:data.date_submitted, amount:data.amount, details:data.details, status: data.status});
                    setState(data.filter((claim: IClaim) => claim.customer_id === props.currentUser?.patient_id));
                });
        } catch (err) {
            setErrorMessage('Could not communicate with API');
        }
    }




    return (
        <>
            <h3>View The Claims Of A Patient</h3>
            <br /><br />
            <button id="home-button" onClick={navHome}>Home</button>
            <button id="claims-button" onClick={getClaims}>Update Claims</button>
            <div>{errorMessage}</div>
            <br /><br />
            {
                state.map((claim) => {
                    return <ClaimCard key={claim.id} claim={claim} />
                })
            }

        </>
    )
}

export default ViewClaimsPatient;