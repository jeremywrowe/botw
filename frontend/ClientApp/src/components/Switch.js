import React from 'react';
import { Button } from 'react-bootstrap';

export default ({ selected, onClick, label }) => (
  <Button bsStyle={ selected ? 'danger' : 'success' } bsSize="xsmall" onClick={onClick}>
    {label}
  </Button>
);