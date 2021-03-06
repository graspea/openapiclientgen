import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
export namespace MyNS {
	export interface GetAutoScalingGroupRecommendationsResponse {
		nextToken?: string;
		autoScalingGroupRecommendations?: Array<AutoScalingGroupRecommendation>;
		errors?: Array<GetRecommendationError>;
	}


	/** Describes an Auto Scaling group recommendation. */
	export interface AutoScalingGroupRecommendation {
		accountId?: string;
		autoScalingGroupArn?: string;
		autoScalingGroupName?: string;
		finding?: AutoScalingGroupRecommendationFinding;
		utilizationMetrics?: Array<UtilizationMetric>;
		lookBackPeriodInDays?: number;

		/** Describes the configuration of an Auto Scaling group. */
		currentConfiguration?: AutoScalingGroupConfiguration;
		recommendationOptions?: Array<AutoScalingGroupRecommendationOption>;
		lastRefreshTimestamp?: Date;
	}

	export enum AutoScalingGroupRecommendationFinding { Underprovisioned = 0, Overprovisioned = 1, Optimized = 2, NotOptimized = 3 }


	/** Describes a utilization metric of a resource, such as an Amazon EC2 instance. */
	export interface UtilizationMetric {
		name?: UtilizationMetricName;
		statistic?: UtilizationMetricStatistic;
		value?: number;
	}

	export enum UtilizationMetricName { Cpu = 0, Memory = 1 }

	export enum UtilizationMetricStatistic { Maximum = 0, Average = 1 }


	/** Describes the configuration of an Auto Scaling group. */
	export interface AutoScalingGroupConfiguration {
		desiredCapacity?: number;
		minSize?: number;
		maxSize?: number;
		instanceType?: string;
	}


	/** Describes a recommendation option for an Auto Scaling group. */
	export interface AutoScalingGroupRecommendationOption {

		/** Describes the configuration of an Auto Scaling group. */
		configuration?: AutoScalingGroupConfiguration;
		projectedUtilizationMetrics?: Array<UtilizationMetric>;
		performanceRisk?: number;
		rank?: number;
	}


	/** <p>Describes an error experienced when getting recommendations.</p> <p>For example, an error is returned if you request recommendations for an unsupported Auto Scaling group, or if you request recommendations for an instance of an unsupported instance family.</p> */
	export interface GetRecommendationError {
		identifier?: string;
		code?: string;
		message?: string;
	}

	export interface GetAutoScalingGroupRecommendationsRequest {
		accountIds?: Array<string>;
		autoScalingGroupArns?: Array<string>;
		nextToken?: string;
		maxResults?: number;
		filters?: Array<Filter>;
	}


	/** Describes a filter that returns a more specific list of recommendations. */
	export interface Filter {
		name?: FilterName;
		values?: Array<string>;
	}

	export enum FilterName { Finding = 0, RecommendationSourceType = 1 }

	export interface OptInRequiredException {
	}

	export interface InternalServerException {
	}

	export interface ServiceUnavailableException {
	}

	export interface AccessDeniedException {
	}

	export interface InvalidParameterValueException {
	}

	export interface ResourceNotFoundException {
	}

	export interface MissingAuthenticationToken {
	}

	export interface ThrottlingException {
	}

	export interface GetEC2InstanceRecommendationsResponse {
		nextToken?: string;
		instanceRecommendations?: Array<InstanceRecommendation>;
		errors?: Array<GetRecommendationError>;
	}


	/** Describes an Amazon EC2 instance recommendation. */
	export interface InstanceRecommendation {
		instanceArn?: string;
		accountId?: string;
		instanceName?: string;
		currentInstanceType?: string;
		finding?: AutoScalingGroupRecommendationFinding;
		utilizationMetrics?: Array<UtilizationMetric>;
		lookBackPeriodInDays?: number;
		recommendationOptions?: Array<InstanceRecommendationOption>;
		recommendationSources?: Array<RecommendationSource>;
		lastRefreshTimestamp?: Date;
	}


	/** Describes a recommendation option for an Amazon EC2 instance. */
	export interface InstanceRecommendationOption {
		instanceType?: string;
		projectedUtilizationMetrics?: Array<UtilizationMetric>;
		performanceRisk?: number;
		rank?: number;
	}


	/** Describes the source of a recommendation, such as an Amazon EC2 instance or Auto Scaling group. */
	export interface RecommendationSource {
		recommendationSourceArn?: string;
		recommendationSourceType?: RecommendationSourceRecommendationSourceType;
	}

	export enum RecommendationSourceRecommendationSourceType { Ec2Instance = 0, AutoScalingGroup = 1 }

	export interface GetEC2InstanceRecommendationsRequest {
		instanceArns?: Array<string>;
		nextToken?: string;
		maxResults?: number;
		filters?: Array<Filter>;
		accountIds?: Array<string>;
	}

	export interface GetEC2RecommendationProjectedMetricsResponse {
		recommendedOptionProjectedMetrics?: Array<RecommendedOptionProjectedMetric>;
	}


	/** Describes a projected utilization metric of a recommendation option. */
	export interface RecommendedOptionProjectedMetric {
		recommendedInstanceType?: string;
		rank?: number;
		projectedMetrics?: Array<ProjectedMetric>;
	}


	/** Describes a projected utilization metric of a recommendation option, such as an Amazon EC2 instance. */
	export interface ProjectedMetric {
		name?: UtilizationMetricName;
		timestamps?: Array<string>;
		values?: Array<number>;
	}

	export interface GetEC2RecommendationProjectedMetricsRequest {
		instanceArn: string;
		stat: UtilizationMetricStatistic;
		period: number;
		startTime: Date;
		endTime: Date;
	}

	export interface GetEnrollmentStatusResponse {
		status?: GetEnrollmentStatusResponseStatus;
		statusReason?: string;
		memberAccountsEnrolled?: boolean;
	}

	export enum GetEnrollmentStatusResponseStatus { Active = 0, Inactive = 1, Pending = 2, Failed = 3 }

	export interface GetEnrollmentStatusRequest {
	}

	export interface GetRecommendationSummariesResponse {
		nextToken?: string;
		recommendationSummaries?: Array<RecommendationSummary>;
	}


	/** A summary of a recommendation. */
	export interface RecommendationSummary {
		summaries?: Array<Summary>;
		recommendationResourceType?: RecommendationSourceRecommendationSourceType;
		accountId?: string;
	}


	/** The summary of a recommendation. */
	export interface Summary {
		name?: AutoScalingGroupRecommendationFinding;
		value?: number;
	}

	export interface GetRecommendationSummariesRequest {
		accountIds?: Array<string>;
		nextToken?: string;
		maxResults?: number;
	}

	export interface UpdateEnrollmentStatusResponse {
		status?: GetEnrollmentStatusResponseStatus;
		statusReason?: string;
	}

	export interface UpdateEnrollmentStatusRequest {
		status: GetEnrollmentStatusResponseStatus;
		includeMemberAccounts?: boolean;
	}

	export enum Finding { Underprovisioned = 0, Overprovisioned = 1, Optimized = 2, NotOptimized = 3 }

	export enum MetricStatistic { Maximum = 0, Average = 1 }

	export enum Status { Active = 0, Inactive = 1, Pending = 2, Failed = 3 }

	export enum MetricName { Cpu = 0, Memory = 1 }

	export enum RecommendationSourceType { Ec2Instance = 0, AutoScalingGroup = 1 }

	@Injectable()
	export class MyClient {
		constructor(@Inject('baseUri') private baseUri: string = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/', private http: HttpClient) {
		}

		/**
		 * <p>Returns Auto Scaling group recommendations.</p> <p>AWS Compute Optimizer currently generates recommendations for Auto Scaling groups that are configured to run instances of the M, C, R, T, and X instance families. The service does not generate recommendations for Auto Scaling groups that have a scaling policy attached to them, or that do not have the same values for desired, minimum, and maximum capacity. In order for Compute Optimizer to analyze your Auto Scaling groups, they must be of a fixed size. For more information, see the <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/what-is.html">AWS Compute Optimizer User Guide</a>.</p>
		 * Post #X-Amz-Target=ComputeOptimizerService.GetAutoScalingGroupRecommendations
		 * @return {GetAutoScalingGroupRecommendationsResponse} Success
		 */
		GetAutoScalingGroupRecommendations(requestBody: GetAutoScalingGroupRecommendationsRequest): Observable<GetAutoScalingGroupRecommendationsResponse> {
			return this.http.post<GetAutoScalingGroupRecommendationsResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.GetAutoScalingGroupRecommendations', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}

		/**
		 * <p>Returns Amazon EC2 instance recommendations.</p> <p>AWS Compute Optimizer currently generates recommendations for Amazon Elastic Compute Cloud (Amazon EC2) and Amazon EC2 Auto Scaling. It generates recommendations for M, C, R, T, and X instance families. For more information, see the <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/what-is.html">AWS Compute Optimizer User Guide</a>.</p>
		 * Post #X-Amz-Target=ComputeOptimizerService.GetEC2InstanceRecommendations
		 * @return {GetEC2InstanceRecommendationsResponse} Success
		 */
		GetEC2InstanceRecommendations(requestBody: GetEC2InstanceRecommendationsRequest): Observable<GetEC2InstanceRecommendationsResponse> {
			return this.http.post<GetEC2InstanceRecommendationsResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.GetEC2InstanceRecommendations', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}

		/**
		 * Returns the projected utilization metrics of Amazon EC2 instance recommendations.
		 * Post #X-Amz-Target=ComputeOptimizerService.GetEC2RecommendationProjectedMetrics
		 * @return {GetEC2RecommendationProjectedMetricsResponse} Success
		 */
		GetEC2RecommendationProjectedMetrics(requestBody: GetEC2RecommendationProjectedMetricsRequest): Observable<GetEC2RecommendationProjectedMetricsResponse> {
			return this.http.post<GetEC2RecommendationProjectedMetricsResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.GetEC2RecommendationProjectedMetrics', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}

		/**
		 * <p>Returns the enrollment (opt in) status of an account to the AWS Compute Optimizer service.</p> <p>If the account is a master account of an organization, this operation also confirms the enrollment status of member accounts within the organization.</p>
		 * Post #X-Amz-Target=ComputeOptimizerService.GetEnrollmentStatus
		 * @return {GetEnrollmentStatusResponse} Success
		 */
		GetEnrollmentStatus(requestBody: GetEnrollmentStatusRequest): Observable<GetEnrollmentStatusResponse> {
			return this.http.post<GetEnrollmentStatusResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.GetEnrollmentStatus', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}

		/**
		 * <p>Returns the optimization findings for an account.</p> <p>For example, it returns the number of Amazon EC2 instances in an account that are under-provisioned, over-provisioned, or optimized. It also returns the number of Auto Scaling groups in an account that are not optimized, or optimized.</p>
		 * Post #X-Amz-Target=ComputeOptimizerService.GetRecommendationSummaries
		 * @return {GetRecommendationSummariesResponse} Success
		 */
		GetRecommendationSummaries(requestBody: GetRecommendationSummariesRequest): Observable<GetRecommendationSummariesResponse> {
			return this.http.post<GetRecommendationSummariesResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.GetRecommendationSummaries', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}

		/**
		 * <p>Updates the enrollment (opt in) status of an account to the AWS Compute Optimizer service.</p> <p>If the account is a master account of an organization, this operation can also enroll member accounts within the organization.</p>
		 * Post #X-Amz-Target=ComputeOptimizerService.UpdateEnrollmentStatus
		 * @return {UpdateEnrollmentStatusResponse} Success
		 */
		UpdateEnrollmentStatus(requestBody: UpdateEnrollmentStatusRequest): Observable<UpdateEnrollmentStatusResponse> {
			return this.http.post<UpdateEnrollmentStatusResponse>(this.baseUri + '#X-Amz-Target=ComputeOptimizerService.UpdateEnrollmentStatus', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json;charset=UTF-8' } });
		}
	}

	export enum GetAutoScalingGroupRecommendationsX_Amz_Target { ComputeOptimizerService_GetAutoScalingGroupRecommendations = 0 }

	export enum GetEC2InstanceRecommendationsX_Amz_Target { ComputeOptimizerService_GetEC2InstanceRecommendations = 0 }

	export enum GetEC2RecommendationProjectedMetricsX_Amz_Target { ComputeOptimizerService_GetEC2RecommendationProjectedMetrics = 0 }

	export enum GetEnrollmentStatusX_Amz_Target { ComputeOptimizerService_GetEnrollmentStatus = 0 }

	export enum GetRecommendationSummariesX_Amz_Target { ComputeOptimizerService_GetRecommendationSummaries = 0 }

	export enum UpdateEnrollmentStatusX_Amz_Target { ComputeOptimizerService_UpdateEnrollmentStatus = 0 }

}

