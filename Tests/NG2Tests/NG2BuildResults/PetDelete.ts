import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
export namespace MyNS {
	@Injectable()
	export class MyClient {
		constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient) {
		}

		/**
		 * Deletes a pet
		 * Delete pet/{petId}
		 * @param {number} petId Pet id to delete
		 * @return {void} 
		 */
		DeletePet(petId: number): Observable<HttpResponse<string>> {
			return this.http.delete(this.baseUri + 'pet/' + petId, { observe: 'response', responseType: 'text' });
		}
	}

}

