import { DataGrid } from '@mui/x-data-grid';

/**
 * Flight Prices
 */

const columns = [
  { field: 'originLocation', headerName: 'Departure airport', width: 70 },
  { field: 'destinationLocation', headerName: 'Arrival airport', width: 70 },
  { field: 'departureDate', headerName: 'Departure date', width: 130 },

  { field: 'arrivalDate', headerName: 'Return date', width: 130 },

  {
    field: 'persons',
    headerName: 'Number of passenger',
    width: 130,
  },
  { field: 'currency', headerName: 'Currency', width: 130 },
  { field: 'numberOfStops', headerName: 'Number of stops', width: 130 },
  { field: 'price', headerName: 'Total price', width: 130 },
];

const FlightPrices = (props) => {
  const { flightOffers } = props;

  return (
    <DataGrid
      rows={flightOffers}
      columns={columns}
      pageSize={5}
      rowsPerPageOptions={[5]}
    />
  );
};

export default FlightPrices;
