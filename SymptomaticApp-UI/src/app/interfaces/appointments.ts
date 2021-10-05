import { Doctor } from "./doctor";
import {Client } from "./client";

export interface Appointment
{
  id: number,
  dateCreated: Date,
  clientId: number,
  doctorId: number,
  clientFirstName: string,
  clientLastName: string,
  clientContact: string,
  patientSymptoms: string,
  startTime: Date,
  endTime: Date,
  client: Client,
  doctor: Doctor
}
