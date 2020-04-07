create table votesystem_votos(
	id int NOT NULL AUTO_INCREMENT,
	login varchar(250) NOT NULL,
	ip varchar(50) NOT NULL,
	data_voto DATETIME NOT NULL,
	PRIMARY KEY (id)
);

create table votesystem_tops(
	id int NOT NULL AUTO_INCREMENT,
	link_votacao varchar(250) NOT NULL,
	nome_top varchar(150) NOT NULL,
	link_imagem varchar(250) NOT NULL,
	PRIMARY KEY (id)
);

create table votesystem_rewards(
	id int NOT NULL AUTO_INCREMENT,
	item_id int NOT NULL,
	quantidade int NOT NULL,
	enchant_level int NOT NULL DEFAULT 0,
	votos_por_login_de int NOT NULL DEFAULT 0,
	votos_por_login_ate int NOT NULL DEFAULT 0,
	PRIMARY KEY (id)
);