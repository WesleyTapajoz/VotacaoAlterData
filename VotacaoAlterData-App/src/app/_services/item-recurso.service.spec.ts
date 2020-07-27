/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ItemRecursoService } from './item-recurso.service';

describe('Service: ItemRecurso', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ItemRecursoService]
    });
  });

  it('should ...', inject([ItemRecursoService], (service: ItemRecursoService) => {
    expect(service).toBeTruthy();
  }));
});
