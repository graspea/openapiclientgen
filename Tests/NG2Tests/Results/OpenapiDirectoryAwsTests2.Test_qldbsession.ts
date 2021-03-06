import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
export namespace MyNS {
	export interface SendCommandResult {

		/** Contains the details of the started session. */
		StartSession?: StartSessionResult;

		/** Contains the details of the started transaction. */
		StartTransaction?: StartTransactionResult;

		/** Contains the details of the ended session. */
		EndSession?: EndSessionResult;

		/** Contains the details of the committed transaction. */
		CommitTransaction?: CommitTransactionResult;

		/** Contains the details of the aborted transaction. */
		AbortTransaction?: AbortTransactionResult;

		/** Contains the details of the executed statement. */
		ExecuteStatement?: ExecuteStatementResult;

		/** Contains the page that was fetched. */
		FetchPage?: FetchPageResult;
	}


	/** Contains the details of the started session. */
	export interface StartSessionResult {
		SessionToken?: string;
	}


	/** Contains the details of the started transaction. */
	export interface StartTransactionResult {
		TransactionId?: string;
	}


	/** Contains the details of the ended session. */
	export interface EndSessionResult {
	}


	/** Contains the details of the committed transaction. */
	export interface CommitTransactionResult {
		TransactionId?: string;
		CommitDigest?: string;
	}


	/** Contains the details of the aborted transaction. */
	export interface AbortTransactionResult {
	}


	/** Contains the details of the executed statement. */
	export interface ExecuteStatementResult {

		/** Contains details of the fetched page. */
		FirstPage?: Page;
	}


	/** Contains details of the fetched page. */
	export interface Page {
		Values?: Array<ValueHolder>;
		NextPageToken?: string;
	}


	/** A structure that can contain an Amazon Ion value in multiple encoding formats. */
	export interface ValueHolder {
		IonBinary?: string;
		IonText?: string;
	}


	/** Contains the page that was fetched. */
	export interface FetchPageResult {

		/** Contains details of the fetched page. */
		Page?: Page;
	}

	export interface SendCommandRequest {
		SessionToken?: string;

		/** Specifies a request to start a new session. */
		StartSession?: StartSessionRequest;

		/** Specifies a request to start a transaction. */
		StartTransaction?: StartTransactionRequest;

		/** Specifies a request to end the session. */
		EndSession?: EndSessionRequest;

		/** Contains the details of the transaction to commit. */
		CommitTransaction?: CommitTransactionRequest;

		/** Contains the details of the transaction to abort. */
		AbortTransaction?: AbortTransactionRequest;

		/** Specifies a request to execute a statement. */
		ExecuteStatement?: ExecuteStatementRequest;

		/** Specifies the details of the page to be fetched. */
		FetchPage?: FetchPageRequest;
	}


	/** Specifies a request to start a new session. */
	export interface StartSessionRequest {
		LedgerName: string;
	}


	/** Specifies a request to start a transaction. */
	export interface StartTransactionRequest {
	}


	/** Specifies a request to end the session. */
	export interface EndSessionRequest {
	}


	/** Contains the details of the transaction to commit. */
	export interface CommitTransactionRequest {
		TransactionId: string;
		CommitDigest: string;
	}


	/** Contains the details of the transaction to abort. */
	export interface AbortTransactionRequest {
	}


	/** Specifies a request to execute a statement. */
	export interface ExecuteStatementRequest {
		TransactionId: string;
		Statement: string;
		Parameters?: Array<ValueHolder>;
	}


	/** Specifies the details of the page to be fetched. */
	export interface FetchPageRequest {
		TransactionId: string;
		NextPageToken: string;
	}

	export interface BadRequestException {
	}

	export interface InvalidSessionException {
	}

	export interface OccConflictException {
	}

	export interface RateExceededException {
	}

	export interface LimitExceededException {
	}

	@Injectable()
	export class MyClient {
		constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient) {
		}

		/**
		 * <p>Sends a command to an Amazon QLDB ledger.</p> <note> <p>Instead of interacting directly with this API, we recommend that you use the Amazon QLDB Driver or the QLDB Shell to execute data transactions on a ledger.</p> <ul> <li> <p>If you are working with an AWS SDK, use the QLDB Driver. The driver provides a high-level abstraction layer above this <code>qldbsession</code> data plane and manages <code>SendCommand</code> API calls for you. For information and a list of supported programming languages, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/getting-started-driver.html">Getting started with the driver</a> in the <i>Amazon QLDB Developer Guide</i>.</p> </li> <li> <p>If you are working with the AWS Command Line Interface (AWS CLI), use the QLDB Shell. The shell is a command line interface that uses the QLDB Driver to interact with a ledger. For information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/data-shell.html">Accessing Amazon QLDB using the QLDB Shell</a>.</p> </li> </ul> </note>
		 * Post #X-Amz-Target=QLDBSession.SendCommand
		 * @return {SendCommandResult} Success
		 */
		SendCommand(requestBody: SendCommandRequest): Observable<SendCommandResult> {
			return this.http.post<SendCommandResult>(this.baseUri + '#X-Amz-Target=QLDBSession.SendCommand', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}
	}

	export enum SendCommandX_Amz_Target { QLDBSession_SendCommand = 0 }

}

