import React from 'react';
import Enzyme from 'enzyme';
import EnzymeAdapter from 'enzyme-adapter-react-16';
import { setupWrapper, findElementByTestId } from '../testHelpers';
import { ReactElement } from 'react';
import SuperheroCard from './SuperheroCard';

Enzyme.configure({ adapter: new EnzymeAdapter() });

