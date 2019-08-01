import { ReactElement } from 'react';
import { shallow, ShallowWrapper, mount, ReactWrapper } from 'enzyme';

export const setupWrapper = (component: ReactElement, props: any = {}, state: any = {}): ShallowWrapper => {
  const wrapper = shallow(component, props);
  if (state) {
    wrapper.setState(state);
  }
  return wrapper;
};

export const findElementByTestId = (wrapper: ShallowWrapper, dataTestId: string) => {
  return wrapper.find(`[data-testid='${dataTestId}']`);
};
