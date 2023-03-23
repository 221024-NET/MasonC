import React, { useEffect, useState } from "react";

const AsyncAwait =() => {
    const [patients, setPatients] = useState([]);

    const fetchData = async () => {
        const response = fetch("http://localhost:7120/patients")
        const data = await (await response).json()
        setPatients(data)
    }

    useEffect(() => {
        fetchData()
    }, [])

    return (
        <div>
          {patients.length > 0 && (
            <ul>
              {patients.map(user => (
                <li key={user.id}>{user.name}</li>
              ))}
            </ul>
          )}
        </div>
      )
}