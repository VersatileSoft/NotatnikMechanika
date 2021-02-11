docker build -f "D:\Projekty\NotatnikMechanika\Api\Server\Dockerfile" --force-rm -t misiek231/notatnikmechanikaserver:latest "D:\Projekty\NotatnikMechanika" 
docker push misiek231/notatnikmechanikaserver:latest
ssh root@mechanicstoolkit.tk "cd notatnik-mechanika;docker-compose pull notatnikmechanika.server;docker-compose up -d notatnikmechanika.server"


