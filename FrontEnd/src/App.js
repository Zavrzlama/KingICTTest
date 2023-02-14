import './App.css';

import { Grid, Typography } from '@mui/material';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import axios from 'axios';
import { useState } from 'react';

import { BASE_URL } from '../src/constants/constants';
import FlightOffersForm from './components/FlightOffersForm';
import FlightPrices from './components/FlightOffersTable';

function App() {
  // flights offers state
  const [flightOffers, setFlightOffers] = useState([]);

  // fetch flights offer
  const fetchFlightOffers = (
    originLocation,
    destinationLocation,
    departureDate,
    arrivalDate,
    adults,
    currency,
  ) => {
    axios
      .get(`${BASE_URL}/FlightOffer`, {
        params: {
          OriginLocation: originLocation,
          DestinationLocation: destinationLocation,
          DepartureDate: departureDate,
          Adults: adults,
          ...(arrivalDate && { ArrivalDate: arrivalDate }),
          ...(currency && { Currency: currency }),
        },
      })
      .then((response) => {
        console.log(response);
        setFlightOffers(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Typography variant="h5" sx={{ p: 2, fontWeight: 700 }}>
        Flight prices
      </Typography>
      <Grid container spacing={2} sx={{ p: 2 }}>
        <Grid item md={6}>
          <FlightOffersForm fetchFlightOffers={fetchFlightOffers} />
        </Grid>
        <Grid item md={6}>
          <FlightPrices flightOffers={flightOffers} banana={1} />
        </Grid>
      </Grid>
    </LocalizationProvider>
  );
}

export default App;
