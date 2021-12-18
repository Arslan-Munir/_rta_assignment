echo "***************** Restarting all existing containers *****************"
docker restart $(docker ps -a -q)

echo "***************** Building image from docker file *****************"
docker build -t RtaAssignment .

echo "*******************************************************************"
docker images

echo "***************** Image prune *****************"
docker image prune

echo "***************** Building container from image *****************"
docker stop RtaAssignment
docker rm RtaAssignment
docker run --network=services -p 8000:80 --name RtaAssignment RtaAssignment

echo "***************** Done *****************"

read
