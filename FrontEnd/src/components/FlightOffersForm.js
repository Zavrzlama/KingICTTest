import { Button, MenuItem, Stack, TextField, Typography } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from 'dayjs';
import { useFormik } from 'formik';

import { airports, currencies } from '../constants/constants';

const initialValues = {
  originLocation: '',
  destinationLocation: '',
  departureDate: null,
  arrivalDate: null,
  adults: 1,
  currency: '',
};

/**
 * Flight offers form
 */
const FlightOffersForm = (props) => {
  const { fetchFlightOffers } = props;

  const formik = useFormik({
    initialValues,
    onSubmit(values) {
      const dateDepartureFormated = dayjs(values.departureDate).format('YYYY-MM-DD');
      const dateArrivalFormated = dayjs(values.arrivalDate).isValid()
        ? dayjs(values.arrivalDate).format('YYYY-MM-DD')
        : null;
      fetchFlightOffers(
        values.originLocation,
        values.destinationLocation,
        dateDepartureFormated,
        dateArrivalFormated,
        values.adults,
        values.currency,
      );
    },
  });

  return (
    <Stack spacing={2} sx={{ mt: 2 }}>
      {/** departure airport */}
      <TextField
        id="originLocation"
        name="originLocation"
        required
        select
        label="Departure Airport"
        fullWidth
        value={formik.values.originLocation}
        onChange={formik.handleChange}
      >
        {airports.map((option) => (
          <MenuItem key={`airport${option}`} value={option}>
            <Typography>{option}</Typography>
          </MenuItem>
        ))}
      </TextField>

      {/** arrival airport */}
      <TextField
        id="destinationLocation"
        name="destinationLocation"
        required
        select
        label="Arrival Airport"
        fullWidth
        value={formik.values.destinationLocation}
        onChange={formik.handleChange}
      >
        {airports.map((option) => (
          <MenuItem key={`airport${option}`} value={option}>
            <Typography>{option}</Typography>
          </MenuItem>
        ))}
      </TextField>

      {/** departure date */}
      <DatePicker
        label="Departure date"
        value={formik.values.departureDate}
        onChange={(value) => formik.setFieldValue('departureDate', value, true)}
        renderInput={(params) => (
          <TextField {...params} fullWidth name="departureDate" required />
        )}
      />

      {/** return date */}
      <DatePicker
        label="Return date"
        value={formik.values.arrivalDate}
        onChange={(value) => formik.setFieldValue('arrivalDate', value, true)}
        renderInput={(params) => (
          <TextField {...params} fullWidth name="arrivalDate" required />
        )}
      />

      {/** number of passengers */}
      <TextField
        id="adults"
        name="adults"
        fullWidth
        label="Number of passengers"
        type="number"
        required
        value={formik.values.adults}
        onChange={formik.handleChange}
      />
      {/** currency */}
      <TextField
        id="currency"
        name="currency"
        required
        select
        label="Currency"
        fullWidth
        value={formik.values.currency}
        onChange={formik.handleChange}
        error={Boolean(formik.errors.currency) && formik.touched.currency}
        onBlur={formik.handleBlur}
      >
        {currencies.map((option) => (
          <MenuItem key={`currency${option}`} value={option}>
            <Typography>{option}</Typography>
          </MenuItem>
        ))}
      </TextField>

      <Button
        color="primary"
        variant="contained"
        fullWidth
        type="submit"
        onClick={() => formik.handleSubmit()}
      >
        Submit
      </Button>
    </Stack>
  );
};

export default FlightOffersForm;
