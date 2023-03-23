import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes } from 'react-router-dom';
import axios from 'axios';
import { Card } from "@blueprintjs/core"

function App() {
  const [patients, setPatients] = useState([])
  useEffect(() => {
    axios.get("https://localhost:7120/patients").then(response => {
      setPatients(response.data)
    })
  }, [])

  return (
    <div className="App">
      <Card>
        <table className="bp3-html-table .modifier">
          <thead>
            <tr>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            {patients.map(patient => {
              return (
                <tr key={patient.id}>
                  <td>{patient.name}</td>
                </tr>
              )
            })}
          </tbody>
        </table>
      </Card>
    </div>
  )
}

export default App;
