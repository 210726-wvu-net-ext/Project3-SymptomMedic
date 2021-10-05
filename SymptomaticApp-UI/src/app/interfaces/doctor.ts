import { Appointment } from "./appointments";
import { Symptom } from "./symptom";

export interface Doctor
{
  id: number,
  firstName: string,
  lastName: string,
  license: string,
  practiceName: string,
  email: string,
  password: string,
  phoneNumber: string,
  doctorSpecialty: string,
  practiceAddress: string,
  practiceCity: string,
  practiceState: string,
  practiceZipcode: number,
  certifications: string,
  education: string,
  gender: string,
  appointments: Appointment[],
  doctorSymptoms: Symptom[]

}
