import { TestBed } from '@angular/core/testing';

import { MonInterceptorInterceptor } from './mon-interceptor.interceptor';

describe('MonInterceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      MonInterceptorInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: MonInterceptorInterceptor = TestBed.inject(MonInterceptorInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
