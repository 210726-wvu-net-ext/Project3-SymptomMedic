import { Appointment } from "./appointments";

export interface Client
{
  id: number,
  firstName: string,
  lastName: string,
  password: string,
  gender: string,
  contactMobile: string,
  address: string,
  city: string,
  state: string,
  country: string,
  zipcode: number,
  birthdate: Date,
  email: string,
  insuranceId: number,
  providerName: string,
  providerId: string,
  appointments: Appointment[]
}
