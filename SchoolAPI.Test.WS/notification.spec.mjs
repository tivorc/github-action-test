import { expect, test } from 'vitest';
import { createClient } from 'graphql-ws';
import webSocketImpl from 'ws';

const TEACHER_NAME = "Napoleon Bonaparte";
const API = process.env.WEBAPP_URL ? `${process.env.WEBAPP_URL}/graphql` : "localhost:5172/graphql";
const query = "subscription { teacherAdded { name } }";
const client = createClient({ url: `ws://${API}`, webSocketImpl });

console.log("Connecting to:", API);

function saveOrder() {
  const headers = { 'Content-Type': 'application/json'};
  const body = {
    query: "mutation ($teacher: TeacherInput!) { saveTeacher(teacher: $teacher) { id } }",
    variables: {
      teacher: {
        name: TEACHER_NAME
      }
    }
  }

  fetch(`http://${API}`, {
    method: 'POST',
    headers,
    body: JSON.stringify(body),
  });
}

test("Should send notification after save an new teacher", () => {
  return new Promise(async (resolve, reject) => {
    client.on("connected", () => saveOrder());

    client.subscribe(
      { query },
      {
        next: data => {
          console.log('data: ', data);
          expect(data.data.teacherAdded.name).toBe(TEACHER_NAME);
          resolve();
        },
        error: error => {
          console.error('error: ', error.message);
          reject();
        }
      },
    );
  });
}, 10000);
