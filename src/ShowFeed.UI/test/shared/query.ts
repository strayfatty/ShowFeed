import 'mocha';
import { expect } from 'chai';

import Query from 'shared/query';

describe('Query', () => {

  it('should return empty string', () => {
    const result = Query.toString();
    expect(result).to.equal('');
  })
});
