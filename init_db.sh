# Launch MSSQL and send to background
/opt/mssql/bin/sqlservr &
pid=$$!
# Wait for it to be available
echo "Waiting for MS SQL to be available ⏳"
/opt/mssql-tools/bin/sqlcmd -l 30 -S localhost -h-1 -V1 -U sa -P $$MSSQL_SA_PASSWORD -Q "SET NOCOUNT ON SELECT \"YAY WE ARE UP\" , @@servername"
is_up=$$?
while [ $$is_up -ne 0 ] ; do 
  echo -e $$(date) 
  /opt/mssql-tools/bin/sqlcmd -l 30 -S localhost -h-1 -V1 -U sa -P $$MSSQL_SA_PASSWORD -Q "SET NOCOUNT ON SELECT \"YAY WE ARE UP\" , @@servername"
  is_up=$$?
  sleep 5 
done
# Run every script in /scripts
# TODO set a flag so that this is only done once on creation, 
#      and not every time the container runs
/opt/mssql-tools/bin/sqlcmd -U sa -P $$MSSQL_SA_PASSWORD -l 30 -e -Q "CREATE DATABASE school"
for foo in /scripts/*.sql
  do /opt/mssql-tools/bin/sqlcmd -U sa -P $$MSSQL_SA_PASSWORD -l 30 -e -i $$foo
done
# trap SIGTERM and send same to sqlservr process for clean shutdown
trap "kill -15 $$pid" SIGTERM
# Wait on the sqlserver process
wait $$pid
exit 0