import { async, inject, TestBed } from '@angular/core/testing';
import { HttpClient, HttpClientModule, HttpErrorResponse } from '@angular/common/http';

import * as namespaces from './ClientApiAuto';
import My_Pet_Client=namespaces.My_Pet_Client;
const apiBaseUri = 'http://localhost:5000/'; //for DemoCoreWeb

export function petClientFactory(http: HttpClient) {
  return new namespaces.My_Pet_Client.PetClient(apiBaseUri, http);
}


export function errorResponseToString(error: HttpErrorResponse | any, ): string {
  let errMsg: string;
  if (error instanceof HttpErrorResponse) {
	if (error.status === 0) {
	  errMsg = 'No response from backend. Connection is unavailable.';
	} else {
	  if (error.message) {
		errMsg = `${error.status} - ${error.statusText}: ${error.message}`;
	  } else {
		errMsg = `${error.status} - ${error.statusText}`;
	  }
	}

	errMsg += error.error ? (' ' + JSON.stringify(error.error)) : '';
	return errMsg;
  } else {
	errMsg = error.message ? error.message : error.toString();
	return errMsg;
  }
}


describe('Pet API', () => {
  let service: namespaces.My_Pet_Client.PetClient;

  beforeEach(async(() => {

	TestBed.configureTestingModule({
	  imports: [HttpClientModule],
	  providers: [
		{
		  provide: namespaces.My_Pet_Client.PetClient,
		  useFactory: petClientFactory,
		  deps: [HttpClient],

		},

	  ]
	});

	service = TestBed.get(namespaces.My_Pet_Client.PetClient);
  }));

  afterEach(function () {
  });

  it('getPetById', (done) => {
	service.GetPetById(12).subscribe(
	  data => {
		expect(data.name).toBe('Narco');
		done();
	  },
	  error => {
		fail(errorResponseToString(error));
		done();
	  }
	);
  }
  );

  it('FindPetsByStatus', (done) => {
	service.FindPetsByStatus([My_Pet_Client.PetStatus.sold, My_Pet_Client.PetStatus.pending]).subscribe(
	  data => {
		expect(data.length).toBe(3);
		done();
	  },
	  error => {
		fail(errorResponseToString(error));
		done();
	  }
	);
  }
  );

  it('DeletePet', (done) => {
	service.DeletePet(9).subscribe(
	  data => {
		fail("Not good.")
		done();
	  },
	  error => {
		const msg = errorResponseToString(error);
		console.debug('DeletePet: '+msg);
		expect(msg).toContain("NoSuchPet");
		done();
	  }
	);
  }
  );

 



});



