import React from 'react';
import Enzyme from 'enzyme';
import EnzymeAdapter from 'enzyme-adapter-react-16';
import { findElementByTestId, setupWrapper, setupFullWrapper, findElementByTestIdFullWrapper } from './testHelpers';
import App from './App';
import { ReactElement } from 'react';

Enzyme.configure({ adapter: new EnzymeAdapter() });

describe('App Component Tests', () => {
  let app: ReactElement;

  beforeEach(() => {
    app = <App />;
  })

  test('renders without crashing', () => {
    const appComponent = findElementByTestId(setupWrapper(app), 'app-component');
    expect(appComponent.length).toBe(1);
  });

  test('results do not render without state being set', () => {
    const wrapper = setupWrapper(app);
    const battleSummaryRow = findElementByTestId(wrapper, 'battle-summary-row');
    expect(battleSummaryRow.length).toBe(0);
  });

  test('results do render with battle summary', () => {
    const state = {
      battleSummary: {
        attacker: '',
        defender: ''
      }
    }

    const wrapper = setupWrapper(app, {}, state);
    const battleSummaryRow = findElementByTestId(wrapper, 'battle-summary-row');
    expect(battleSummaryRow.length).toBe(1);
  });  
  
  // test('Battle summary attackers displays', () => {
  //   const state = {
  //     battleSummary: {
  //       attacker: 'This is a test',
  //       defender: ''
  //     }
  //   }
  //   const wrapper = setupFullWrapper(app, {}, state);
  //   const battleSummaryRow = findElementByTestIdFullWrapper(wrapper, 'battle-result-summary-attacker');
  //   expect(battleSummaryRow.text()).toContain('This is a test');
  // });
});