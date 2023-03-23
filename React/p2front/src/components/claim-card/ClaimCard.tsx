import { IClaim } from "../../models/claim";
import React from "react";

interface ClaimProps {
    claim: IClaim
}

function ClaimCard(props: ClaimProps) {

    return (
        <>
            <div id="card">
                <p>Claim ID Number: {props.claim.id}</p>
                <p>Customer ID Number: {props.claim.customer_id}</p>
                <p>Claim Amount: ${props.claim.amount}</p>
                <p>Claim Details: {props.claim.details}</p>
                <p>Claim Status: {props.claim.status}</p>
            </div>
        </>
    )
}

export default ClaimCard;