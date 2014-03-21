all: docker

git.tar.gz:
	tar czf git.tar.gz .git

docker: git.tar.gz Dockerfile
	docker build -t kongo2002/centos-servicestack .
